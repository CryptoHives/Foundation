| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     1,242.3 ns |      4.71 ns |      4.40 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3,245.9 ns |     37.38 ns |     33.14 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       553.0 ns |      4.43 ns |      3.93 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     1,757.5 ns |      8.83 ns |      8.26 ns |    1112 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     8,904.6 ns |     48.42 ns |     45.29 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    20,079.1 ns |    102.77 ns |     91.10 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     3,893.9 ns |     23.28 ns |     21.77 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |     9,570.4 ns |     45.67 ns |     35.66 ns |    1112 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    74,633.1 ns |    307.36 ns |    287.51 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   155,904.9 ns |  2,181.21 ns |  2,040.30 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    30,739.0 ns |    163.34 ns |    152.78 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |    71,813.6 ns |    351.21 ns |    311.34 ns |    1112 B |
|                                               |              |                |              |              |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 1,117,234.2 ns |  5,278.43 ns |  4,937.45 ns |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 2,474,719.2 ns | 17,959.75 ns | 16,799.56 ns |    1112 B |
|                                               |              |                |              |              |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   489,533.4 ns |  1,995.42 ns |  1,557.90 ns |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 1,153,164.2 ns |  9,061.20 ns |  8,032.52 ns |    1112 B |