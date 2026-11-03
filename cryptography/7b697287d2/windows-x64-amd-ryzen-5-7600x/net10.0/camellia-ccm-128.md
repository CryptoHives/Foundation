| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|----------:|
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128B         |     1.812 μs |  0.0032 μs |  0.0028 μs |  18,620 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 128B         |     2.863 μs |  0.0108 μs |  0.0101 μs |     306 B |    2184 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128B         |     1.747 μs |  0.0071 μs |  0.0066 μs |  18,658 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 128B         |     2.660 μs |  0.0086 μs |  0.0081 μs |     386 B |    2072 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 1KB          |    11.298 μs |  0.0379 μs |  0.0354 μs |  18,622 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 1KB          |    16.078 μs |  0.0495 μs |  0.0439 μs |     306 B |    7560 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 1KB          |    11.082 μs |  0.0212 μs |  0.0188 μs |  18,668 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 1KB          |    15.942 μs |  0.0689 μs |  0.0645 μs |     383 B |    6552 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 8KB          |    86.901 μs |  0.3193 μs |  0.2987 μs |  18,637 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 8KB          |   122.856 μs |  0.8414 μs |  0.7871 μs |     306 B |   50568 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 8KB          |    85.967 μs |  0.3420 μs |  0.3199 μs |  18,672 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 8KB          |   122.827 μs |  0.2229 μs |  0.1976 μs |     383 B |   42392 B |
|                                                 |              |              |            |            |           |           |
| Decrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128KB        | 1,370.515 μs |  2.1909 μs |  1.9421 μs |  18,637 B |         - |
| Decrypt · Camellia-128-CCM (BouncyCastle)       | 128KB        | 2,023.550 μs | 12.1055 μs | 11.3234 μs |     306 B |  787861 B |
|                                                 |              |              |            |            |           |           |
| Encrypt · Camellia-128-CCM (CryptoHives-Scalar) | 128KB        | 1,429.218 μs |  3.6539 μs |  3.2391 μs |  18,672 B |         - |
| Encrypt · Camellia-128-CCM (BouncyCastle)       | 128KB        | 1,939.320 μs |  3.0991 μs |  2.8989 μs |     383 B |  656792 B |