| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     1,110.8 ns |      6.69 ns |      6.26 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3,298.2 ns |     10.92 ns |     10.22 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       557.4 ns |      3.56 ns |      3.33 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     1,706.9 ns |      7.01 ns |      6.56 ns |    1112 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     7,931.3 ns |     51.41 ns |     45.57 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    21,151.6 ns |     55.14 ns |     51.58 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     3,995.2 ns |     18.67 ns |     17.46 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |     9,655.6 ns |     34.89 ns |     32.64 ns |    1112 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    62,305.1 ns |    409.58 ns |    383.12 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   163,883.5 ns |    711.38 ns |    665.43 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    31,435.5 ns |    135.38 ns |    126.63 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |    72,980.7 ns |    348.46 ns |    325.95 ns |    1112 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   996,870.0 ns |  6,172.43 ns |  5,773.69 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 2,614,428.3 ns | 13,750.42 ns | 12,862.15 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   501,902.6 ns |  2,484.54 ns |  2,324.04 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 1,160,874.0 ns |  5,570.10 ns |  5,210.28 ns |    1112 B |