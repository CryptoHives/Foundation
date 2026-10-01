| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |       791.5 ns |      6.18 ns |      5.79 ns |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    11,850.1 ns |     52.60 ns |     49.20 ns |    1024 B |
|                                               |              |                |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |       734.5 ns |      2.31 ns |      2.16 ns |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    11,571.0 ns |     82.67 ns |     77.33 ns |     896 B |
|                                               |              |                |              |              |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |     5,636.0 ns |     14.91 ns |     13.22 ns |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    62,538.4 ns |    280.46 ns |    262.35 ns |    3712 B |
|                                               |              |                |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |     5,166.8 ns |     15.94 ns |     14.91 ns |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    61,332.2 ns |    225.13 ns |    210.58 ns |    2688 B |
|                                               |              |                |              |              |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |    44,252.4 ns |     94.72 ns |     79.10 ns |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   467,193.9 ns |  1,115.12 ns |  1,043.08 ns |   25216 B |
|                                               |              |                |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |    40,486.2 ns |    118.49 ns |    110.83 ns |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   459,013.2 ns |  2,081.17 ns |  1,946.73 ns |   17024 B |
|                                               |              |                |              |              |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        |   711,782.2 ns |  1,060.16 ns |    991.67 ns |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 7,437,834.7 ns | 17,422.23 ns | 15,444.36 ns |  393935 B |
|                                               |              |                |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        |   646,545.3 ns |  1,113.45 ns |  1,041.52 ns |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 7,283,615.6 ns | 32,582.52 ns | 30,477.71 ns |  262836 B |