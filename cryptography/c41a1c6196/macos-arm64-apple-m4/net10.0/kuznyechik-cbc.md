| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |       791.4 ns |      0.37 ns |      0.33 ns |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    11,090.3 ns |     25.88 ns |     24.21 ns |    1024 B |
|                                               |              |                |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128B         |       738.4 ns |      0.76 ns |      0.71 ns |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128B         |    11,523.8 ns |     25.93 ns |     24.26 ns |     896 B |
|                                               |              |                |              |              |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |     5,611.8 ns |      7.08 ns |      6.62 ns |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    57,915.5 ns |    127.89 ns |    119.63 ns |    3712 B |
|                                               |              |                |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 1KB          |     5,178.7 ns |     12.67 ns |     11.86 ns |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 1KB          |    61,202.7 ns |    102.03 ns |     95.44 ns |    2688 B |
|                                               |              |                |              |              |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |    43,995.9 ns |     38.26 ns |     35.79 ns |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   433,157.5 ns |    623.91 ns |    583.61 ns |   25216 B |
|                                               |              |                |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 8KB          |    40,680.5 ns |     79.30 ns |     74.18 ns |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 8KB          |   457,911.8 ns |    792.94 ns |    741.71 ns |   17024 B |
|                                               |              |                |              |              |           |
| Decrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        |   705,374.9 ns |    383.23 ns |    358.47 ns |         - |
| Decrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 6,885,003.4 ns | 11,800.04 ns | 11,037.76 ns |  393935 B |
|                                               |              |                |              |              |           |
| Encrypt · Kuznyechik-CBC (CryptoHives-Scalar) | 128KB        |   650,253.6 ns |    436.10 ns |    407.93 ns |         - |
| Encrypt · Kuznyechik-CBC (OpenGost)           | 128KB        | 7,273,783.9 ns | 15,222.59 ns | 14,239.22 ns |  262836 B |