using YggdrasilAPI.BusinessLogic;
using YggdrasilAPI.DBConnection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IAssetData, AssetDataControl>();
builder.Services.AddSingleton<IAssetAccess, AssetDatabaseAccess>();
builder.Services.AddSingleton<ICounterpartData, CounterpartDataControl>();
builder.Services.AddSingleton<ICounterpartAccess, CounterpartDatabaseAccess>();
builder.Services.AddSingleton<IAreaData, AreaDataControl>();
builder.Services.AddSingleton<IAreaAccess, AreaDatabaseAccess>();
builder.Services.AddSingleton<IAssetTypeData, AssetTypeDataControl>();
builder.Services.AddSingleton<IAssetTypeAccess, AssetTypeDatabaseAccess>();
builder.Services.AddSingleton<ITechTypeData, TechTypeDataControl>();
builder.Services.AddSingleton<ITechTypeAccess, TechTypeDatabaseAccess>();
builder.Services.AddSingleton<IStateData, StateDataControl>();
builder.Services.AddSingleton<IStateAccess, StateDatabaseAccess>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
