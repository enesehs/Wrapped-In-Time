# Oyun ve Uygulama Akademisi AI Odaklı Game Jam

## Grup: 122
**Geliştirici:** Enes Hacısağır  
**Oyun Tipi:** Zaman Kontrollü Parkur  
**Oyun İsmi:** Wrapped In Time


## Kullandığım Assetler ve Linkleri
- [Fantasy Forest Environment - Free Demo](https://assetstore.unity.com/packages/3d/environments/fantasy/fantasy-forest-environment-free-demo-35361)
- [SMM Stylized Grass](https://assetstore.unity.com/packages/3d/environments/smm-stylized-grass-184975)
- [Dirty Lens Flare](https://assetstore.unity.com/packages/tools/particles-effects/dirty-lens-flare-9133)
- [Skybox Series Free](https://assetstore.unity.com/packages/2d/textures-materials/sky/skybox-series-free-103633)
- [Real Stars Skybox Lite](https://assetstore.unity.com/packages/3d/environments/sci-fi/real-stars-skybox-lite-116333)

## Scriptler ve Açıklamaları
- **PlayerMovement.cs:** Karakter kontrolü, zıplama, hızlı koşma, eğilme vb.
- **PlayerHealth.cs:** Karaktere can verme, can yenileme, UI ile bağlantı içeriyor.
- **PlayerFallDamage.cs:** Karakterin yüksekten düşüp düşmediğini kontrol ediyor. Ayrıca karakter öldüğü zaman Rigidbody ve UI fonksiyonlarını çalıştırıyor.
- **Parkour.cs:** Q ve E ile hem zamanı hem de parkuru yönetebildiğimiz script.
- **ParkourDef.cs:** Parkur elementini XYZ koordinatında spesifik hızda kontrol etmeyi sağlayan script.
- **deneme/NextLevel.cs:** Trigger Box ile bir sonraki sahneyi yüklüyor.
- **GameManagerScript.cs:** UI ve ana menüyü kontrol ediyor.
