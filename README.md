<img src="https://media.githubusercontent.com/media/nepatiess/PopBalloon/main/PopBalloon/Assets/UI/github%20banner%201.png" >

# 🎈 Balloon Popper: Skorunu Yükselt, Balonları Patlat!

Bu, Unity 2022.3.37f1 ile geliştirilen bir **refleks tabanlı skor oyunu**dur. Oyuncu farklı renkteki balonlara tıklayarak skor kazanmaya veya kaybetmeye çalışır. Hedef, en yüksek skoru yaparak oyunu kazanmaktır!

--- 

## 🎯 Oyun Özellikleri

### ✅ Oyun Akışı
- Oyuncu, **ana menü** üzerinden oyuna başlar veya çıkış yapar.
- Oyun başladığında farklı renklerde balonlar rastgele yatay konumlarda belirir ve yukarı doğru çıkar.
- Oyuncu bu balonlara tıklayarak onları patlatır, puan toplar veya kaybeder.
- Her balonun **rengine göre** puan değeri vardır:
  - 🟦 Mavi: +1 puan
  - 🟩 Yeşil: +5 puan
  - ⬛ Siyah: -2 puan
- Mavi ve Yeşil balonlar, **ekranın üstüne ulaşırsa da puan kazandırır.**
- Skor **50'ye ulaşırsa** ya da **0’ın altına düşerse** oyun sona erer.

### 🎨 Balon Sistemi
- Balonlar `BalloonType` sınıfı ile tanımlanır ve Scriptable yapı mantığına benzer şekilde dinamik olarak yönetilir.
- Yeni balon türleri (renk, skor, efekt) **kod değiştirilmeden** `Inspector` üzerinden kolayca eklenebilir.

### 🔊 Ses ve Efektler
- Her balon patladığında bir **Particle Effect** gösterilir.
- Balon patlatma ses efekti çalışır.
- Menü ve oyun için **ayrı müzikler** vardır.
- Müzikler sahneye göre otomatik başlar/durur (`MusicManager.cs`).

### 🧾 Oyun Sonu Ekranı
- Kullanıcının:
  - Toplam skoru
  - En yüksek skoru (kayıtlı)
  - Patlatılan balon renklerinin sayısı gösterilir.
- **Yeniden Başlat** ve **Ana Menüye Dön** seçenekleri bulunur.


---

## ⚙️ Teknik Detaylar

### 🎮 Kullanılan Teknolojiler
- **Unity 2022.3.37f1** <img src="https://media.githubusercontent.com/media/nepatiess/PopBalloon/main/PopBalloon/Assets/UI/github%20png.png" width="200" align="right"/>
- **C# ile programlama**
- **TextMeshPro** ile UI yönetimi
- **PlayerPrefs** ile skor ve veri kayıt sistemi 
- **AudioSource** ile arka plan müzikleri ve ses efektleri
- **SceneManager** ile sahne geçişleri
- **Coroutines** ile balon üretim kontrolü


---

## 💡 Genişletilebilirlik

Bu projede:
- **Tek bir spawner** ile birden fazla balon yönetilebilir.
- Yeni balonlar sadece prefab ve listeye ekleme ile entegre olur (hardcoded değil).
- Manager script’ler (MusicManager, ScoreManager) Singleton olarak yazılmıştır.
- Kod yorumlarla desteklenmiş, her bir modül tek sorumluluk prensibine uygun olarak bölünmüştür.

---

## 🛠️ Kurulum ve Çalıştırma

1. Bu projeyi klonla veya indir:
```bash
git clone https://github.com/kullaniciadi/PopBalloon.git

```

---

## 📈 Git Kuralları
- gitignore dosyası projeye eklenmiştir (Library, Temp, obj, .vs, .csproj, .unitypackage dosyaları hariç tutulmuştur).
- Geliştirme boyunca anlamlı commit mesajları ile kod takibi yapılmıştır.
- Geliştirme süreci boyunca düzenli olarak GitHub'a push edilmiştir.

---

## 👩‍💻 Geliştirici
- Zeynep Koz
- Düzce Üniversitesi - Bilgisayar Mühendisliği
- 📬 İletişim: <div>
  <a href="https://www.linkedin.com/in/zeynep-koz34/" target="_blank">
    <img src="https://img.shields.io/static/v1?message=LinkedIn&logo=linkedin&label=&color=191919&logoColor=white&labelColor=&style=for-the-badge" height="35" alt="linkedin logo"  />
  </a>
  <a href="https://discord.com/users/467302273911881740" target="_blank">
    <img src="https://img.shields.io/static/v1?message=Discord&logo=discord&label=&color=191919&logoColor=white&labelColor=&style=for-the-badge" height="35" alt="discord logo"  />
  </a>
  <a href="https://www.instagram.com/nepatiess/" target="_blank">
    <img src="https://img.shields.io/static/v1?message=Instagram&logo=instagram&label=&color=191919&logoColor=white&labelColor=&style=for-the-badge" height="35" alt="instagram logo"  />
  </a>

<img src="https://media.githubusercontent.com/media/nepatiess/PopBalloon/main/PopBalloon/Assets/UI/github%20banner%202.png">
