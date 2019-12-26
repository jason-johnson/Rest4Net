# Rest4Net
A library to simplify doing REST programming

## Another REST library?

REST has been misunderstood for a long time, especially with things like "levels of REST compliance" and "RESTful", etc.
but in fact it is very simple: REST is what your web browser has always done.  Your web browser does not know "URLs" (let's
ignore search bar behavior for the moment).  What it does know is data types.  It knows HTML, JS, CSS and it can be taught
things like PDF.  It knows versions of those types as well.  It has a pretty sophisticated handling in regards to types but
it does not know URLs.

When you view REST in this way, a lot of concerns people have about "RESTful" services and the like disappear (e.g. "How do
we encode versioning in our URL?").  This also changes how coupling works.  "RESTful" services are actually doing HTTP-RPC
which means the client is tightly coupled with the server at the URL level.  In an actual REST service the coupling is at
the data type level.  For example, you never need a new version of your web browser if google moves around some web pages.
You only need a new browser to support new versions of data types (e.g. HTML5).

There are many reasons for the confusion that has always surrounded REST programming but we find that rather than spending
time analysing spilled milk or trying to combat misunderstanding with yet more articles on REST, the best way forward is to
provide libraries that enable REST programming the correct way.

## Conventions

This library aims to integrate in the expected way with the existing ASP.NET framework.  Your application is configured with
attributes.  You will note that there is no way to specify URLs in this library.  This is on purpose.  URLs are an
implementation detail that the Rest4Net library will manage.

REST controllers must be derived from `RestController`

```
public class HomeController : RestController
``

Somewhere in the application there must be a `RestEntrypointAttribute`

```
[RestEntrypoint]
public Home GetInitialResource()
{
  var result = new Home
  {
    Greeting = "Hello and welcome to the coffee shop!",
    Coffees = coffeeRepository.GetAll(c => c.Count > 0).Select(c => c.Name),
    Pastries = pastryRepository.GetAll(p => p.Count > 0)
  };

  return result;
}
```

Other methods must be deocrated with `RestServiceMethodAttribute`

```
[RestServiceMethod]
public IEnumerable<Coffee> GetAll()
{
  return repository.GetAll();
}
```

Methods return objects in the model but Rest4Net will automatically replace these with contracts which carry
`RestContractAttribute`

```
[RestContract(typeof(Coffee))]
public class CoffeeContract : RestContractBase<Coffee>
{
}

[RestContract(typeof(Home), Version = "1.2")]
public class HomeContract : OldHomeContract
{
  public string Greeting
  {
    get => Model.Greeting;
    set => Model.Greeting = value;
  }
}
```