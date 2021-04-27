using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Имя")]
       
        [Required(ErrorMessage ="длина имени не менее 5 символов")]
        public string Name { get; set; }

        [Display(Name = "Введите фамилие")]
        
        [Required(ErrorMessage = "длина фамилии не менее 5 символов")]
        public string SurName { get; set; }

        [Display(Name = "Адрес")]
       
        [Required(ErrorMessage = "длина адреса не менее 10 символов")]
        public string Adress { get; set; }

        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
       
        [Required(ErrorMessage = "длина телефона не менее 10 знаков")]
        public string Phone { get; set; }

        [Display(Name = "Введите Email")]
        [DataType(DataType.EmailAddress)]
     
        [Required(ErrorMessage = "длина email не менее 5 символов")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
