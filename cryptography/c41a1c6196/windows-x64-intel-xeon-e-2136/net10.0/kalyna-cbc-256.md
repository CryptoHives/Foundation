| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     2,072.3 ns |      3.81 ns |      3.57 ns |   1,431 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     5,828.3 ns |     16.91 ns |     15.82 ns |   2,935 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       904.2 ns |      1.64 ns |      1.54 ns |   1,433 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3,233.3 ns |     31.88 ns |     29.82 ns |   2,933 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |    14,252.3 ns |     24.71 ns |     23.12 ns |   1,431 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    38,172.8 ns |     51.82 ns |     45.94 ns |   2,935 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     6,146.7 ns |     16.62 ns |     14.73 ns |   1,433 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    17,036.2 ns |    133.95 ns |    125.30 ns |   2,933 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |   112,071.3 ns |    153.32 ns |    143.42 ns |   1,431 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   288,723.7 ns |    620.37 ns |    518.04 ns |   2,935 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    48,057.6 ns |     79.74 ns |     70.69 ns |   1,433 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   132,037.9 ns |    936.48 ns |    830.16 ns |   2,935 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 1,787,583.6 ns |  3,138.66 ns |  2,935.90 ns |   1,431 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 4,641,160.7 ns | 10,949.08 ns |  9,706.07 ns |   2,933 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   765,084.5 ns |  1,353.77 ns |  1,200.08 ns |   1,433 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 2,063,014.2 ns | 39,936.79 ns | 39,223.27 ns |   2,935 B |    1112 B |