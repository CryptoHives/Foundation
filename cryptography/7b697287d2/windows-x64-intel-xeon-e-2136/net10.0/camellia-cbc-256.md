| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     1.002 μs | 0.0043 μs | 0.0038 μs |   1,311 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1.716 μs | 0.0039 μs | 0.0037 μs |   2,935 B |     592 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     1.218 μs | 0.0037 μs | 0.0034 μs |   1,313 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1.629 μs | 0.0063 μs | 0.0059 μs |   2,933 B |     592 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     7.083 μs | 0.0161 μs | 0.0134 μs |   1,311 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |    11.621 μs | 0.0358 μs | 0.0335 μs |   2,935 B |    2832 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     8.640 μs | 0.0280 μs | 0.0248 μs |   1,313 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |    10.846 μs | 0.0325 μs | 0.0288 μs |   2,933 B |    2832 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    54.823 μs | 0.1529 μs | 0.1430 μs |   1,311 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    88.705 μs | 0.3050 μs | 0.2853 μs |   2,933 B |   20752 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    67.520 μs | 0.2283 μs | 0.2135 μs |   1,313 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |    83.710 μs | 0.2427 μs | 0.2271 μs |   2,933 B |   20752 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        |   878.192 μs | 2.3827 μs | 1.9896 μs |   1,297 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,400.860 μs | 4.5346 μs | 4.2416 μs |   2,935 B |  327952 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 1,078.696 μs | 2.7499 μs | 2.5723 μs |   1,313 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,358.066 μs | 5.9824 μs | 5.5959 μs |   2,935 B |  327952 B |