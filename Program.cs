using HospitalAPI.Middleware;
using HospitalAPI.Repositories;
using HospitalAPI.Repositories.Interfaces;
using HospitalAPI.Services;
using HospitalAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errorMessage = context.ModelState
            .Values
            .SelectMany(v => v.Errors)
            .FirstOrDefault()?.ErrorMessage;

        return new BadRequestObjectResult(new
        {
            Message = errorMessage
        });
    };
});

// Dependency Injection
builder.Services.AddScoped<IPatientService,PatientService>();
builder.Services.AddScoped<IPatientRepository,PatientRepository>();
builder.Services.AddScoped<IDoctorService,DoctorService>();
builder.Services.AddScoped<IDoctorRepository,DoctorRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IReportService, ReportService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();



// 2. Logging SECOND (captures full request time)
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseRouting();

app.UseMiddleware<ValidationMiddleware>();





app.UseAuthorization();

app.MapControllers();

app.Run();