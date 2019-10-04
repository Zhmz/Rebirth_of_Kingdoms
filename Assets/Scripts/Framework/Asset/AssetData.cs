using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROKCore.ROKAsset
{
    public class AssetGUIData
    {
        public string Id { get; set; }
        public string EnumName { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string ABName { get; set; }

    }
    public class AssetCharacterData
    {
    }

    public class RootObject
    {
        public List<AssetGUIData> GUIAssets { get; set; }
        public List<AssetCharacterData> CharacterAssets { get; set; }
    }
}
