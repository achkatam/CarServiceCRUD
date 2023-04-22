using CarServiceCRUD.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var cars = ListOfCars();

app.UseHttpsRedirection();

// Get calls
// Returns the list of cars
app.MapGet("/car", () =>
{
    return cars;
});

// Return a car
app.MapGet("/car/{id}", (int id) =>
{
    var car = cars.FirstOrDefault(c => c.Id == id);

    if (car is null)
    {
        return Results.NotFound("Not existing car!");
    }

    return Results.Ok(car);
});

// Add a new car
app.MapPost("/car", (Car car) =>
{
    cars.Add(car);

    return cars;
});

// Updates car's problems
app.MapPut("/car/{id}", (Car updateCar, int id) =>
{
    var car = cars.FirstOrDefault(c => c.Id == id);

    if (car is null)
    {
        return Results.NotFound("Not existing car!");
    }
    // gives and error if you try to change immutable property. JUST FOR THE EXAMPLE
    //car.Year = updateCar.Year;

    car.Problem = updateCar.Problem;

    return Results.Ok(cars);
});

app.MapDelete("/car/{id}", (int id) =>
{
    var car = cars.FirstOrDefault(c => c.Id == id);

    if (car is null)
    {
        return Results.NotFound("Not existing car!");
    }

    cars.Remove(car);

    return Results.Ok(cars);
});


app.Run();

List<Car> ListOfCars()
{
    List<Car> list = new List<Car>()
    {
        new Car { Id = 1, Make = "Toyota", Model = "Corolla", Year = 2016, Problem = "Needs an oil change" },
        new Car { Id = 2, Make = "Honda", Model = "Accord", Year = 2017, Problem = "Needs new wipers" },
        new Car { Id = 3, Make = "Ford", Model = "F-150", Year = 2017, Problem = "Needs tire rotation" },
        new Car { Id = 4, Make = "Chevrolet", Model = "Silverado", Year = 2017, Problem = "Needs an oil change" },
        new Car { Id = 5, Make = "Nissan", Model = "Altima", Year = 2016, Problem = "Needs new wipers" },
        new Car { Id = 6, Make = "BMW", Model = "3 Series", Year = 2017, Problem = "Needs tire rotation" },
        new Car { Id = 7, Make = "Mercedes-Benz", Model = "C-Class", Year = 2016, Problem = "Needs an oil change" },
        new Car { Id = 8, Make = "Audi", Model = "A4", Year = 2017, Problem = "Needs new wipers" },
        new Car { Id = 9, Make = "Lexus", Model = "ES", Year = 2019, Problem = "Needs tire rotation" },
        new Car { Id = 10, Make = "Subaru", Model = "Outback", Year = 2019, Problem = "Needs an oil change" },
        new Car { Id = 11, Make = "Mazda", Model = "CX-5", Year = 2016, Problem = "Needs new wipers" },
        new Car { Id = 12, Make = "Kia", Model = "Sorento", Year = 2019, Problem = "Needs tire rotation" },
        new Car { Id = 13, Make = "Hyundai", Model = "Santa Fe", Year = 2017, Problem = "Needs an oil change" },
        new Car { Id = 14, Make = "Volvo", Model = "XC60", Year = 2017, Problem = "Needs new wipers" },
        new Car { Id = 15, Make = "Jeep", Model = "Wrangler", Problem = "Needs tire rotation" },
        new Car { Id = 16, Make = "Ram", Model = "1500", Year = 2016, Problem = "Needs an oil change" },
        new Car { Id = 17, Make = "GMC", Model = "Sierra", Year = 2016, Problem = "Needs new wipers" },
        new Car { Id = 18, Make = "Porsche", Model = "911", Year = 2019, Problem = "Needs tire rotation" },
        new Car { Id = 19, Make = "Tesla", Model = "Model S", Year = 2019, Problem = "Needs an oil change" },
        new Car { Id = 20, Make = "Ferrari", Model = "488", Year = 2016, Problem = "Needs new wipers" }
    };
    return list;
}