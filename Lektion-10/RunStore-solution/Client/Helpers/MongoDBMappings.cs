using Client.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace Client.Helpers;

public static class MongoDBMappings
{
    public static void MapProperties()
    {
        BsonClassMap.RegisterClassMap<Product>(map =>
        {
            map.AutoMap();
            map.MapIdMember(p => p.Id).SetIdGenerator(StringObjectIdGenerator.Instance);
            map.IdMemberMap.SetSerializer(new StringSerializer(BsonType.ObjectId));
            map.MapMember(p => p.Description).SetElementName("description");
            map.MapMember(p => p.ImageUrl).SetElementName("imageUrl");
            map.MapMember(p => p.ItemNumber).SetElementName("itemNumber");
            map.MapMember(p => p.Name).SetElementName("name");
            map.MapMember(p => p.Price).SetElementName("price");
            map.MapMember(p => p.Supplier).SetElementName("supplier");
        });

        BsonClassMap.RegisterClassMap<Customer>(map =>
        {
            map.AutoMap();
            map.IdMemberMap.SetSerializer(new StringSerializer(BsonType.ObjectId));
            map.MapMember(c => c.FirstName).SetElementName("firstName");
            map.MapMember(c => c.LastName).SetElementName("lastName");
            map.MapMember(c => c.Email).SetElementName("email");
            map.MapMember(c => c.Phone).SetElementName("phone");
            map.MapMember(c => c.Address).SetElementName("address");
        });

        BsonClassMap.RegisterClassMap<Address>(map =>
        {
            map.AutoMap();
            map.MapMember(c => c.AddressLine).SetElementName("addressLine");
            map.MapMember(c => c.PostalCode).SetElementName("postalCode");
            map.MapMember(c => c.City).SetElementName("city");
        });

        BsonClassMap.RegisterClassMap<Supplier>(map =>
        {
            map.AutoMap();
            map.IdMemberMap.SetSerializer(new StringSerializer(BsonType.ObjectId));
            map.MapMember(s => s.Name).SetElementName("supplierName");
        });

        BsonClassMap.RegisterClassMap<SalesOrder>(map =>
        {
            map.AutoMap();
            map.IdMemberMap.SetSerializer(new StringSerializer(BsonType.ObjectId));
            map.MapMember(o => o.OrderDate).SetDefaultValue("orderDate");
            map.MapMember(o => o.OrderNumber).SetDefaultValue("orderNumber");
            map.MapMember(o => o.Customer).SetDefaultValue("customer");
            map.MapMember(o => o.OrderValue).SetDefaultValue("orderValue");
        });
    }
}
