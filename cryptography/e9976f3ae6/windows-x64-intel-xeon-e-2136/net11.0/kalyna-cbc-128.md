| Description                                   | TestDataSize | Mean           | Error       | StdDev      | Code Size | Allocated |
|---------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|----------:|
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |     1,512.0 ns |     0.58 ns |     0.54 ns |  10,743 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     4,648.9 ns |     9.22 ns |     8.62 ns |  13,925 B |     872 B |
|                                               |              |                |             |             |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128B         |       683.9 ns |     1.22 ns |     1.14 ns |  10,553 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128B         |     2,411.4 ns |     8.16 ns |     7.63 ns |   7,776 B |     872 B |
|                                               |              |                |             |             |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |    10,498.3 ns |    14.25 ns |    13.33 ns |  10,553 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    27,738.0 ns |    26.52 ns |    24.81 ns |  13,735 B |     872 B |
|                                               |              |                |             |             |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 1KB          |     4,552.3 ns |     4.38 ns |     4.10 ns |   4,218 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 1KB          |    12,241.6 ns |    29.91 ns |    26.52 ns |   7,776 B |     872 B |
|                                               |              |                |             |             |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    82,316.1 ns |    86.69 ns |    81.09 ns |   4,218 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |   215,404.5 ns |   399.73 ns |   373.91 ns |   7,776 B |     872 B |
|                                               |              |                |             |             |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 8KB          |    35,651.7 ns |    12.80 ns |    10.69 ns |   4,218 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 8KB          |    94,432.6 ns |   134.77 ns |   126.07 ns |  13,735 B |     872 B |
|                                               |              |                |             |             |           |           |
| Decrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        | 1,318,605.5 ns |   212.70 ns |   188.55 ns |   4,218 B |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 3,286,263.0 ns | 4,436.45 ns | 4,149.86 ns |  13,735 B |     872 B |
|                                               |              |                |             |             |           |           |
| Encrypt · Kalyna-128-CBC (CryptoHives-Scalar) | 128KB        |   570,690.8 ns |   943.20 ns |   836.12 ns |   4,218 B |         - |
| Encrypt · Kalyna-128-CBC (BouncyCastle)       | 128KB        | 1,502,193.0 ns | 4,478.25 ns | 4,188.96 ns |  13,925 B |     872 B |