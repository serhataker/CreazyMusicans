using CreazyMusicans.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CreazyMusicans.Entities
{
    public class MusiciansEntity
    {
        // It is created  entity class add vwe added basic property with validation
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter the mussican Name")]
        [StringLength(50,MinimumLength=3,ErrorMessage ="Please enter the name 3 beetwen 50")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please Enter Musiacans Job")]
        [RegularExpression("^(Ünlü Çalgı Çalar|Akor Sihirbazı|Tonlama Meraklısı)$",ErrorMessage ="It is not found")]
        public string Job { get; set; }
        [Musican(funny:1)] //It is custom Attribute for the funnyproperty
        public string FunnyProperty { get; set; }

    }
}
