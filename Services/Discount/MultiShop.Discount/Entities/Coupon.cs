using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Discount.Entities;

public class Coupon
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string CouponId { get; set; }
    public string Code { get; set; }
    public int Rate { get; set; }
    public bool IsActive { get; set; }
    public DateTime ValidDate { get; set; }
}
