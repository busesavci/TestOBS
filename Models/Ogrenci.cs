using System;    
using System.Collections.Generic;    
using System.ComponentModel.DataAnnotations;    
using System.Linq;    
using System.Threading.Tasks;  
using Microsoft.EntityFrameworkCore;  
    
namespace _1._3.Models    
{    
        
    
    public class Ogrenci
    {    
        public int ogrenci_no { get; set; }    
        [Required]    
        public string ogrenci_ad { get; set; }    
        [Required]    
        public string ogrenci_soyad { get; set; }    
        [Required]       
        public string ogrenci_email { get; set; }    
        [Required]  
        public string ogrenci_sifre { get; set; } 
    }

}