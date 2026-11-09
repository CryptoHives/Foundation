| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     1,589.1 ns |     20.29 ns |     18.98 ns |   1,431 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     4,709.0 ns |     41.01 ns |     38.36 ns |   2,935 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       681.4 ns |     10.32 ns |      9.65 ns |   1,433 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     2,470.0 ns |     26.52 ns |     24.80 ns |   2,933 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |    10,890.7 ns |    148.85 ns |    139.23 ns |   1,431 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    27,891.7 ns |    298.97 ns |    279.65 ns |   2,935 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     4,726.9 ns |     31.42 ns |     29.39 ns |   1,433 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    12,870.3 ns |    162.42 ns |    151.93 ns |   2,933 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    85,539.4 ns |    945.70 ns |    884.61 ns |   1,431 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   216,790.6 ns |  3,433.33 ns |  3,211.54 ns |   2,935 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    36,653.2 ns |    433.02 ns |    405.05 ns |   1,433 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   100,402.4 ns |  1,588.66 ns |  1,486.03 ns |   2,935 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 1,370,762.8 ns |  9,305.10 ns |  8,248.73 ns |   1,431 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 3,412,621.6 ns | 52,677.55 ns | 49,274.62 ns |   2,933 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   582,171.0 ns |  9,410.41 ns |  8,802.50 ns |   1,433 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 1,546,214.6 ns | 22,531.08 ns | 21,075.59 ns |   2,935 B |    1112 B |