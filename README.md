# AssetsPlugin

> **AssetsPlugin** – a convenient and simple static content management system for Unity projects.

🟢 [Read in Russian / Читать на русском](README.ru.md)

## Description

AssetsPlugin provides a flexible and centralized way to manage all static data of a game object:  
*prefabs, UI icons, parameters (e.g., max health), audio files, etc.*  
Everything needed for an object is stored under a single key.

🎯 **Core Idea:**  
Access all data related to an object via a unique key.

> ⚠️ _The plugin works only with static data — these are strictly object configs, not runtime states!_

---

## Installation

1. Copy all contents to the `Plugins/AssetsPlugin` directory of your Unity project.

> _(Additional installation methods will be added soon)_

---

## Quick Start

```csharp
[DefaultExecutionOrder(-1000)]
public class Bootstrap : MonoBehaviour
{
    [SerializeField] AssetsService assetsService;

    void Awake()
    {
        // Resources
        var pathPrefab = "Prefabs/";

        var assetsBuilder = new BuilderAssets();

        assetsBuilder.AddAsset(GameAsset.Hero)
                     .Join(new AssetPrefab(pathPrefab + "Hero", pooled: false));

        assetsService.RegisterAssets(assetsBuilder);
    }

    void Start()
    {
        // Spawn Hero
        var prefab = assetsService.Get(GameAsset.Hero).As<AssetPrefab>().prefab;
        Instantiate(prefab, Vector3.zero, Quaternion.identity);
    }
}

public enum GameAsset
{
    Hero
}
```

---

## Out-of-the-Box

- `AssetPrefab`
- `AssetPrefabs`

---

## Extensibility

Adding a new asset type is easy:

```csharp
public class AssetStartStats : AssetAbstract
{
    public float speed;
    public float health;
}
```

---

## Feedback & Support

If you have questions, suggestions, or want to join the discussion, welcome to our [Discord](https://discord.gg/TvStQ8aG) 👈

---

**Enhance your project, use with comfort, and don’t forget to star the repo! ⭐**
