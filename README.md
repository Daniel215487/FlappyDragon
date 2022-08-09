# FlappyDragon

[![](https://img.youtube.com/vi/5d9jOSt6V0U/hqdefault.jpg)](https://www.youtube.com/watch?v=5d9jOSt6V0U)

[PC執行檔 下載](https://drive.google.com/file/d/1hgXGaTzQZ0xBm-tQ3w36NOqI0Xlwnp7r/view?usp=sharing)

此專案皆使用免費素材-[素材來源](https://www.aigei.com/)
# Introduce
這是一款仿照FlappyBird製作的遊戲，起因是之前的面試當中有面試官提出來是否能在15分鐘之內做出來，當時用的筆電容量不夠裝Unity就沒實作了。
之後就想說，有空可以來試試看，結果當然是沒有15分鐘做出來啦，斷斷續續的做也做了一陣子 哈哈

# Architecture
![](https://i.imgur.com/eeGXrNW.png)

# Conclusion
整體而言，覺得有達到FlappyBird的感覺，原本的想法是想說直接控制座標的上下來控制速度跟秒數，但發現手感欠佳，去參考FlappyBird的程式碼後，它是用AddForce向上跳，用Rigidbody做自由落體，也不是沒想過，但這樣就要對Force添加的力跟質量的大小進行微調才有手感，第一時間覺得若要交給企劃修改有點不夠直觀。

製作過程中算是複習了一些2D的操作，之前2D多半只做些UI動畫，像這樣製作2D的全遊戲基本沒有過。再來是思考一些架構類的邏輯還是花了一下時間想了一下，希望將各自的職責跟邏輯劃分清楚，之後才方便擴充，這部分還要再多幾個專案練練手才行。

以上是個人的製作心得，歡迎多多指教及批評。
