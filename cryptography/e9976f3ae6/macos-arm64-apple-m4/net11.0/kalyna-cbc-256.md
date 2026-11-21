| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     1,122.0 ns |      7.22 ns |      6.40 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3,296.3 ns |      6.38 ns |      5.97 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       558.9 ns |      3.30 ns |      3.08 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     1,697.3 ns |      4.94 ns |      4.62 ns |    1112 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     8,029.5 ns |     27.47 ns |     24.35 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    21,191.6 ns |     76.68 ns |     71.72 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     4,031.1 ns |     20.63 ns |     19.30 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |     9,709.9 ns |     55.37 ns |     51.79 ns |    1112 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    63,245.1 ns |    295.07 ns |    276.01 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   164,577.6 ns |    423.95 ns |    375.82 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    31,617.1 ns |    169.25 ns |    158.32 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |    73,594.0 ns |    509.93 ns |    476.99 ns |    1112 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 1,148,904.3 ns | 10,854.11 ns | 10,152.94 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 2,626,363.1 ns |  7,129.74 ns |  6,669.16 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   517,649.3 ns |  2,531.41 ns |  2,367.88 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 1,169,871.5 ns |  8,759.20 ns |  8,193.36 ns |    1112 B |