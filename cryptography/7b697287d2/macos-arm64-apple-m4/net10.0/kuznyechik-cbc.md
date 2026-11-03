| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |       783.9 ns |      0.28 ns |      0.26 ns |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    10,865.0 ns |     25.15 ns |     23.52 ns |    1024 B |
|                                               |              |                |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |       731.8 ns |      0.37 ns |      0.35 ns |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    11,313.2 ns |      7.68 ns |      7.18 ns |     896 B |
|                                               |              |                |              |              |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |     5,531.4 ns |      3.17 ns |      2.96 ns |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    56,764.2 ns |    147.92 ns |    138.37 ns |    3712 B |
|                                               |              |                |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |     5,171.2 ns |     63.98 ns |     56.71 ns |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    60,049.9 ns |     69.39 ns |     54.18 ns |    2688 B |
|                                               |              |                |              |              |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |    43,686.6 ns |     37.94 ns |     33.63 ns |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   423,138.7 ns |  1,183.63 ns |  1,107.17 ns |   25216 B |
|                                               |              |                |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |    40,366.1 ns |     25.99 ns |     21.70 ns |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   448,955.3 ns |    612.39 ns |    572.83 ns |   17024 B |
|                                               |              |                |              |              |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        |   703,034.2 ns |    869.51 ns |    813.34 ns |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 6,727,319.7 ns | 23,189.07 ns | 21,691.07 ns |  393935 B |
|                                               |              |                |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        |   644,649.4 ns |    181.88 ns |    170.13 ns |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 7,132,560.8 ns | 11,219.28 ns | 10,494.52 ns |  262836 B |