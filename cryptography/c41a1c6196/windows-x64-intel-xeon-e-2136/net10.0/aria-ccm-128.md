| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128B         |     8.135 μs | 0.0114 μs | 0.0106 μs |  14,355 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 128B         |    11.043 μs | 0.0193 μs | 0.0181 μs |     310 B |    3448 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128B         |     8.047 μs | 0.0043 μs | 0.0033 μs |  14,411 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 128B         |    10.895 μs | 0.0187 μs | 0.0156 μs |     390 B |    3336 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 1KB          |    52.461 μs | 0.0209 μs | 0.0185 μs |  14,365 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 1KB          |    60.726 μs | 0.1078 μs | 0.0956 μs |     310 B |    8824 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 1KB          |    52.368 μs | 0.0215 μs | 0.0191 μs |  14,415 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 1KB          |    60.770 μs | 0.1610 μs | 0.1506 μs |     387 B |    7816 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 8KB          |   407.181 μs | 0.0677 μs | 0.0566 μs |  14,366 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 8KB          |   463.240 μs | 0.6172 μs | 0.5773 μs |     310 B |   51832 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 8KB          |   407.308 μs | 0.1334 μs | 0.1182 μs |  14,419 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 8KB          |   458.226 μs | 0.7230 μs | 0.6410 μs |     387 B |   43656 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128KB        | 6,491.188 μs | 3.5005 μs | 3.2744 μs |  14,366 B |         - |
| Decrypt · ARIA-128-CCM (BouncyCastle)       | 128KB        | 7,380.214 μs | 8.4127 μs | 7.8692 μs |     310 B |  789125 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-CCM (CryptoHives-Scalar) | 128KB        | 6,491.524 μs | 2.2206 μs | 1.8543 μs |  14,416 B |         - |
| Encrypt · ARIA-128-CCM (BouncyCastle)       | 128KB        | 7,374.878 μs | 7.9430 μs | 7.4299 μs |     387 B |  658056 B |