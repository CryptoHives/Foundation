| Description                                     | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       761.8 ns |     1.63 ns |     1.45 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,249.5 ns |     1.64 ns |     1.28 ns |     592 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |       811.9 ns |     1.64 ns |     1.45 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1,242.9 ns |     3.05 ns |     2.85 ns |     592 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     5,356.3 ns |     8.83 ns |     6.90 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     8,443.5 ns |    20.08 ns |    17.80 ns |    2832 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     5,736.1 ns |    10.33 ns |     9.15 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |     8,354.3 ns |    88.80 ns |    74.15 ns |    2832 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    43,522.3 ns |    55.07 ns |    45.99 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    65,791.9 ns |   192.43 ns |   160.69 ns |   20752 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    45,092.5 ns |    51.45 ns |    45.61 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    64,711.5 ns |   157.40 ns |   131.44 ns |   20752 B |
|                                                 |              |                |             |             |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   708,687.5 ns | 1,134.32 ns | 1,005.55 ns |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,051,067.5 ns | 2,456.51 ns | 2,051.30 ns |  327952 B |
|                                                 |              |                |             |             |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   731,295.6 ns |   954.00 ns |   845.69 ns |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,036,286.8 ns | 2,939.75 ns | 2,749.85 ns |  327952 B |