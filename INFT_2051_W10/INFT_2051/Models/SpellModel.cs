using SQLite;
using SQLiteNetExtensions.Attributes;

namespace INFT_2051.Models
{
    [Table("spells")]
    public class SpellModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(260)]
        public string Name { get; set; }

        [ForeignKey(typeof(CharacterModel))]
        public int CharacterId { get; set; }
    }
}
