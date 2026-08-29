| Description                                   | TestDataSize | Mean         | Error      | StdDev      | Median       | Allocated |
|---------------------------------------------- |------------- |-------------:|-----------:|------------:|-------------:|----------:|
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     3.421 μs |  0.0077 μs |   0.0065 μs |     3.417 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     4.740 μs |  0.0091 μs |   0.0085 μs |     4.739 μs |    1784 B |
|                                               |              |              |            |             |              |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128B         |     1.888 μs |  0.0048 μs |   0.0044 μs |     1.888 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128B         |     2.641 μs |  0.0028 μs |   0.0025 μs |     2.641 μs |    1784 B |
|                                               |              |              |            |             |              |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    22.610 μs |  0.3359 μs |   0.3142 μs |    22.425 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    28.771 μs |  0.3488 μs |   0.3262 μs |    28.759 μs |    1784 B |
|                                               |              |              |            |             |              |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 1KB          |    12.197 μs |  0.0149 μs |   0.0124 μs |    12.203 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 1KB          |    13.920 μs |  0.0194 μs |   0.0181 μs |    13.916 μs |    1784 B |
|                                               |              |              |            |             |              |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   178.113 μs |  3.0702 μs |   2.8719 μs |   177.812 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   212.215 μs |  2.8785 μs |   2.6926 μs |   212.066 μs |    1784 B |
|                                               |              |              |            |             |              |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 8KB          |   106.525 μs |  2.1250 μs |   5.6720 μs |   106.188 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 8KB          |   204.242 μs | 56.5962 μs | 166.8750 μs |   102.939 μs |    1784 B |
|                                               |              |              |            |             |              |           |
| Decrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 2,842.125 μs | 44.7021 μs |  41.8143 μs | 2,825.019 μs |         - |
| Decrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 3,400.408 μs | 41.3874 μs |  38.7138 μs | 3,401.934 μs |    1784 B |
|                                               |              |              |            |             |              |           |
| Encrypt · Kalyna-512-CBC (CryptoHives-Scalar) | 128KB        | 1,569.547 μs | 29.7673 μs |  29.2355 μs | 1,559.682 μs |         - |
| Encrypt · Kalyna-512-CBC (BouncyCastle)       | 128KB        | 1,570.764 μs | 30.5084 μs |  28.5376 μs | 1,564.088 μs |    1784 B |