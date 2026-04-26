# AssetsPlugin

> **AssetsPlugin** — удобная и простая система управления статическим контентом для проектов на Unity.

🟢 [Read in English / Читать на английском](README.md)

## Описание

AssetsPlugin позволяет гибко и централизованно управлять всеми статическими данными игрового объекта:  
*префабами, UI-иконками, параметрами (например, максимальным здоровьем), аудиофайлами и т.д.*  
Всё, что требуется для объекта — всегда находится под одним ключом.

🎯 **Основная идея:**  
По уникальному ключу получить доступ ко всем связанным с объектом данным.

> ⚠️ _Плагин работает только со статическими данными — это исключительно конфиги объекта, не runtime-состояние!_

---

## Установка

1. Скопируйте содержимое в директорию `Plugins/AssetsPlugin` вашего Unity-проекта.

> _(В будущем появятся дополнительные способы установки)_

---

## Быстрый старт

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

## Уже реализовано

- `AssetPrefab`
- `AssetPrefabs`

---

## Расширяемость

Добавить новый тип ассета очень просто:

```csharp
public class AssetStartStats : AssetAbstract
{
    public float speed;
    public float health;
}
```

---

## Обратная связь и поддержка

Если у вас есть вопросы, предложения или вы хотите присоединиться к обсуждению, заходите в наш [Discord](https://discord.gg/TvStQ8aG) 👈

---

**Улучшайте проект, используйте комфортно и оставляйте звездочку! ⭐**
