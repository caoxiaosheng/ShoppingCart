using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ShoppingCart.ViewModels
{
    public class CartItemViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "cartId")]
        public int CartId { get; set; }
        [JsonProperty(PropertyName = "bookId")]
        public int BookId { get; set; }
        [JsonProperty(PropertyName = "quantity")]
        [Range(1,Int32.MaxValue,ErrorMessage = "数量必须大于0")]
        public int Quantity { get; set; }
        [JsonProperty(PropertyName = "book")]
        public virtual BookViewModel Book { get; set; }
    }
}