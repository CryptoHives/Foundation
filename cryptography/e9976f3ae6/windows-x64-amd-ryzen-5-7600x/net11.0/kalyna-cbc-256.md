| Description                                   | TestDataSize | Mean           | Error        | StdDev       | Code Size | Allocated |
|---------------------------------------------- |------------- |---------------:|-------------:|-------------:|----------:|----------:|
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |     1,445.8 ns |      9.05 ns |      8.46 ns |  10,714 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     3,649.0 ns |     23.83 ns |     19.90 ns |  13,887 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128B         |       756.5 ns |      4.60 ns |      4.30 ns |   4,189 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128B         |     1,948.4 ns |     14.51 ns |     13.57 ns |  13,693 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |    10,610.5 ns |     47.51 ns |     44.44 ns |   4,189 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    23,026.2 ns |    186.50 ns |    174.46 ns |  13,887 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 1KB          |     4,525.1 ns |     27.62 ns |     25.84 ns |  10,524 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 1KB          |    10,795.3 ns |     58.70 ns |     54.91 ns |   7,734 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    81,380.9 ns |    538.50 ns |    503.71 ns |  10,524 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |   176,702.8 ns |    849.31 ns |    794.45 ns |   7,734 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 8KB          |    35,485.1 ns |    201.33 ns |    178.47 ns |   4,189 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 8KB          |    80,541.7 ns |    523.15 ns |    489.35 ns |  13,688 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Decrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        | 1,343,400.8 ns |  9,546.66 ns |  8,929.95 ns |   4,189 B |         - |
| Decrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 2,897,290.3 ns | 13,016.09 ns | 11,538.43 ns |  13,688 B |    1112 B |
|                                               |              |                |              |              |           |           |
| Encrypt · Kalyna-256-CBC (CryptoHives-Scalar) | 128KB        |   568,301.6 ns |  3,261.43 ns |  3,050.74 ns |  10,524 B |         - |
| Encrypt · Kalyna-256-CBC (BouncyCastle)       | 128KB        | 1,276,880.4 ns |  5,403.03 ns |  4,789.64 ns |   7,734 B |    1112 B |