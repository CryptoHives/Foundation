| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     1.370 μs | 0.0012 μs | 0.0010 μs |   4,026 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     2.156 μs | 0.0087 μs | 0.0081 μs |  13,735 B |     592 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128B         |     1.628 μs | 0.0007 μs | 0.0006 μs |  10,551 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128B         |     1.999 μs | 0.0081 μs | 0.0071 μs |  13,735 B |     592 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |     9.377 μs | 0.0045 μs | 0.0042 μs |  10,361 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |    13.590 μs | 0.0225 μs | 0.0188 μs |  13,735 B |    2832 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 1KB          |    11.496 μs | 0.0048 μs | 0.0044 μs |   4,026 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 1KB          |    12.979 μs | 0.0214 μs | 0.0189 μs |  13,925 B |    2832 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    73.033 μs | 0.0451 μs | 0.0422 μs |  10,361 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |   105.764 μs | 0.1597 μs | 0.1416 μs |  13,925 B |   20752 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 8KB          |    89.637 μs | 0.0132 μs | 0.0117 μs |   4,026 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 8KB          |   104.131 μs | 0.4133 μs | 0.3451 μs |  13,735 B |   20752 B |
|                                                 |              |              |           |           |           |           |
| Decrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 1,170.979 μs | 0.3062 μs | 0.2864 μs |  10,361 B |         - |
| Decrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,702.502 μs | 3.6640 μs | 3.0596 μs |  13,735 B |  327952 B |
|                                                 |              |              |           |           |           |           |
| Encrypt · Camellia-256-CBC (CryptoHives-Scalar) | 128KB        | 1,431.747 μs | 0.1618 μs | 0.1351 μs |  10,551 B |         - |
| Encrypt · Camellia-256-CBC (BouncyCastle)       | 128KB        | 1,620.482 μs | 4.3431 μs | 3.8501 μs |  13,735 B |  327952 B |