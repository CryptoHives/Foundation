| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128B         |     1.804 μs |  0.0033 μs |  0.0029 μs |  18,620 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 128B         |     2.818 μs |  0.0069 μs |  0.0062 μs |     306 B |    2184 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128B         |     1.741 μs |  0.0035 μs |  0.0031 μs |  18,658 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 128B         |     2.720 μs |  0.0041 μs |  0.0034 μs |     383 B |    2072 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 1KB          |    11.296 μs |  0.0300 μs |  0.0281 μs |  18,633 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 1KB          |    16.010 μs |  0.0662 μs |  0.0619 μs |     306 B |    7560 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 1KB          |    11.199 μs |  0.0248 μs |  0.0220 μs |  18,671 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 1KB          |    15.851 μs |  0.0564 μs |  0.0500 μs |     383 B |    6552 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 8KB          |    85.718 μs |  0.3012 μs |  0.2817 μs |  18,634 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 8KB          |   121.938 μs |  0.6410 μs |  0.5996 μs |     306 B |   50568 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 8KB          |    88.891 μs |  0.1865 μs |  0.1654 μs |  18,672 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 8KB          |   121.544 μs |  0.2941 μs |  0.2456 μs |     383 B |   42392 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128KB        | 1,361.945 μs |  3.1037 μs |  2.5917 μs |  18,637 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 128KB        | 2,005.590 μs | 13.2352 μs | 12.3802 μs |     306 B |  787861 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128KB        | 1,371.661 μs |  2.1261 μs |  1.7754 μs |  18,672 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 128KB        | 1,929.680 μs |  3.8563 μs |  3.6072 μs |     383 B |  656792 B |