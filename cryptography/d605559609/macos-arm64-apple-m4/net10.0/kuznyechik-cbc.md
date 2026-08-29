| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |       780.6 ns |      0.30 ns |      0.25 ns |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    11,654.4 ns |     59.56 ns |     55.71 ns |    1024 B |
|                                               |              |                |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |       744.1 ns |     10.70 ns |     10.01 ns |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    12,186.5 ns |     53.57 ns |     50.11 ns |     896 B |
|                                               |              |                |              |              |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |     5,545.0 ns |     19.56 ns |     16.33 ns |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    61,118.7 ns |    315.44 ns |    295.07 ns |    3712 B |
|                                               |              |                |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |     5,134.6 ns |      1.57 ns |      1.31 ns |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    64,567.5 ns |    322.13 ns |    301.32 ns |    2688 B |
|                                               |              |                |              |              |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |    43,450.1 ns |     78.26 ns |     73.20 ns |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   455,068.5 ns |  1,806.74 ns |  1,508.71 ns |   25216 B |
|                                               |              |                |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |    40,279.2 ns |      9.98 ns |      8.34 ns |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   482,200.2 ns |  2,027.99 ns |  1,797.76 ns |   17024 B |
|                                               |              |                |              |              |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        |   699,766.2 ns |  8,220.11 ns |  6,417.72 ns |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 7,267,696.5 ns | 32,046.33 ns | 28,408.24 ns |  393935 B |
|                                               |              |                |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        |   651,788.0 ns | 10,579.48 ns |  9,378.44 ns |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 7,656,521.2 ns | 20,956.83 ns | 19,603.04 ns |  262836 B |