| Description                                 | TestDataSize | Mean         | Error      | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|-----------:|----------:|----------:|----------:|
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128B         |     9.536 μs |  0.0133 μs | 0.0125 μs |  25,907 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 128B         |    12.048 μs |  0.0178 μs | 0.0166 μs |     310 B |    3848 B |
|                                             |              |              |            |           |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128B         |     9.437 μs |  0.0132 μs | 0.0117 μs |  26,589 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 128B         |    11.960 μs |  0.0128 μs | 0.0107 μs |     390 B |    3696 B |
|                                             |              |              |            |           |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 1KB          |    61.524 μs |  0.0539 μs | 0.0478 μs |  18,805 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 1KB          |    66.916 μs |  0.0712 μs | 0.0666 μs |     310 B |    9224 B |
|                                             |              |              |            |           |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 1KB          |    61.614 μs |  0.0853 μs | 0.0712 μs |  26,717 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 1KB          |    67.660 μs |  0.1057 μs | 0.0937 μs |     390 B |    8176 B |
|                                             |              |              |            |           |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 8KB          |   477.646 μs |  0.5090 μs | 0.4761 μs |  18,808 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 8KB          |   504.712 μs |  0.3716 μs | 0.3294 μs |     310 B |   52232 B |
|                                             |              |              |            |           |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 8KB          |   480.030 μs |  0.3681 μs | 0.3443 μs |  26,537 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 8KB          |   510.656 μs |  0.3494 μs | 0.2918 μs |     390 B |   44016 B |
|                                             |              |              |            |           |           |           |
| Decrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128KB        | 7,600.563 μs |  7.3293 μs | 6.4972 μs |  25,000 B |         - |
| Decrypt · ARIA-256-CCM (BouncyCastle)       | 128KB        | 8,085.661 μs | 10.3360 μs | 8.6310 μs |     310 B |  789552 B |
|                                             |              |              |            |           |           |           |
| Encrypt · ARIA-256-CCM (CryptoHives-Scalar) | 128KB        | 7,624.646 μs |  7.1732 μs | 6.3589 μs |  26,522 B |         - |
| Encrypt · ARIA-256-CCM (BouncyCastle)       | 128KB        | 8,017.190 μs |  4.3755 μs | 4.0928 μs |     390 B |  658416 B |