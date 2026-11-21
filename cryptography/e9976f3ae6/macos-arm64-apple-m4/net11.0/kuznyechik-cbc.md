| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |       781.0 ns |      1.45 ns |      1.36 ns |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    11,417.7 ns |     54.96 ns |     51.41 ns |    1024 B |
|                                               |              |                |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |       787.0 ns |      1.60 ns |      1.50 ns |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    11,686.2 ns |     30.52 ns |     28.55 ns |     896 B |
|                                               |              |                |              |              |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |     5,505.1 ns |     12.97 ns |     12.13 ns |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    58,803.4 ns |    193.08 ns |    180.61 ns |    3712 B |
|                                               |              |                |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |     5,562.1 ns |     25.75 ns |     21.50 ns |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    62,002.2 ns |    373.59 ns |    331.18 ns |    2688 B |
|                                               |              |                |              |              |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |    43,337.7 ns |    113.18 ns |    105.87 ns |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   438,902.5 ns |  1,088.59 ns |  1,018.27 ns |   25216 B |
|                                               |              |                |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |    43,630.1 ns |    129.01 ns |    120.67 ns |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   464,365.2 ns |  1,170.70 ns |  1,095.08 ns |   17024 B |
|                                               |              |                |              |              |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        |   698,312.2 ns |  1,833.11 ns |  1,714.69 ns |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 6,970,003.0 ns | 13,513.27 ns | 11,284.20 ns |  393929 B |
|                                               |              |                |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        |   701,877.0 ns |  2,327.68 ns |  2,177.31 ns |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 7,545,518.7 ns | 31,780.75 ns | 29,727.73 ns |  262833 B |