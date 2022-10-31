using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Item), true), CanEditMultipleObjects]
public class ItemEditorWindow : Editor
{
    public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height)
    {
        Item item = target as Item;
        Sprite spriteItem = item.SpriteItem;

        Texture2D itemTexture2D = null;
        if (spriteItem != null)
        {     
            itemTexture2D = new Texture2D((int)item.SpriteItem.rect.width, (int)item.SpriteItem.rect.height);

            Color[] colors = spriteItem.texture.GetPixels((int)spriteItem.rect.x, (int)spriteItem.rect.y, (int)spriteItem.rect.width, (int)spriteItem.rect.height);
            itemTexture2D.SetPixels(colors);
            itemTexture2D.Apply();
        }

        return itemTexture2D;
    }
}
