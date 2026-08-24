| Description                                   | TestDataSize | Mean            | Error        | StdDev       | Allocated |
|---------------------------------------------- |------------- |----------------:|-------------:|-------------:|----------:|
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |        791.4 ns |     15.27 ns |     32.21 ns |         - |
| Decrypt · Kuznyechik-CBC (Regional)           | 128B         |     11,321.1 ns |     47.52 ns |     44.45 ns |    1024 B |
|                                               |              |                 |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |        871.2 ns |     17.34 ns |     43.82 ns |         - |
| Encrypt · Kuznyechik-CBC (Regional)           | 128B         |     12,340.6 ns |      5.51 ns |      5.16 ns |     896 B |
|                                               |              |                 |              |              |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |      5,524.6 ns |     28.87 ns |     24.11 ns |         - |
| Decrypt · Kuznyechik-CBC (Regional)           | 1KB          |     60,771.1 ns |  1,177.46 ns |  1,489.11 ns |    3712 B |
|                                               |              |                 |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |     24,212.6 ns |     16.14 ns |     12.60 ns |         - |
| Encrypt · Kuznyechik-CBC (Regional)           | 1KB          |    311,989.9 ns |    111.44 ns |     93.06 ns |    2688 B |
|                                               |              |                 |              |              |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |     43,373.9 ns |     10.42 ns |      8.14 ns |         - |
| Decrypt · Kuznyechik-CBC (Regional)           | 8KB          |    456,077.2 ns |  8,886.71 ns | 11,238.84 ns |   25216 B |
|                                               |              |                 |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |    190,000.0 ns |     79.23 ns |     66.16 ns |         - |
| Encrypt · Kuznyechik-CBC (Regional)           | 8KB          |  2,330,011.0 ns |  1,293.22 ns |  1,079.89 ns |   17024 B |
|                                               |              |                 |              |              |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        |    696,596.3 ns |    382.78 ns |    358.06 ns |         - |
| Decrypt · Kuznyechik-CBC (Regional)           | 128KB        |  7,083,940.4 ns | 66,136.53 ns | 51,635.05 ns |  393935 B |
|                                               |              |                 |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        |  3,044,155.2 ns | 17,819.78 ns | 14,880.32 ns |         - |
| Encrypt · Kuznyechik-CBC (Regional)           | 128KB        | 37,012,007.8 ns | 27,338.43 ns | 21,344.05 ns |  262836 B |