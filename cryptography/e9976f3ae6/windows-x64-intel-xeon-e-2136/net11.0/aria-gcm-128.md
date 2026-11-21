| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|----------:|
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128B         |     3.329 μs | 0.0030 μs | 0.0028 μs |     310 B |         - |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128B         |     4.204 μs | 0.0061 μs | 0.0057 μs |     310 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 128B         |     4.746 μs | 0.0122 μs | 0.0114 μs |     310 B |    2040 B |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128B         |     3.214 μs | 0.0018 μs | 0.0015 μs |     390 B |         - |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128B         |     4.150 μs | 0.0064 μs | 0.0059 μs |     390 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 128B         |     4.541 μs | 0.0026 μs | 0.0021 μs |     390 B |    2024 B |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 1KB          |    22.570 μs | 0.0219 μs | 0.0194 μs |     310 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 1KB          |    24.644 μs | 0.0272 μs | 0.0241 μs |     310 B |    4280 B |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 1KB          |    28.737 μs | 0.0311 μs | 0.0260 μs |     310 B |         - |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 1KB          |    22.448 μs | 0.0073 μs | 0.0061 μs |     390 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 1KB          |    24.086 μs | 0.0233 μs | 0.0218 μs |     390 B |    4264 B |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 1KB          |    28.573 μs | 0.0235 μs | 0.0208 μs |     390 B |         - |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 8KB          |   176.405 μs | 0.1067 μs | 0.0946 μs |     310 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 8KB          |   182.125 μs | 0.1733 μs | 0.1536 μs |     310 B |   22200 B |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 8KB          |   223.740 μs | 0.2007 μs | 0.1676 μs |     310 B |         - |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 8KB          |   177.193 μs | 0.1613 μs | 0.1508 μs |     390 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 8KB          |   181.249 μs | 0.1776 μs | 0.1662 μs |     390 B |   22184 B |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 8KB          |   224.451 μs | 0.2258 μs | 0.2112 μs |     390 B |         - |
|                                             |              |              |           |           |           |           |
| Decrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128KB        | 2,822.646 μs | 1.9158 μs | 1.5998 μs |     310 B |         - |
| Decrypt · ARIA-128-GCM (BouncyCastle)       | 128KB        | 2,867.350 μs | 2.1559 μs | 1.9111 μs |     310 B |  329400 B |
| Decrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128KB        | 3,571.255 μs | 4.9571 μs | 4.6369 μs |     310 B |         - |
|                                             |              |              |           |           |           |           |
| Encrypt · ARIA-128-GCM (CryptoHives-PClMul) | 128KB        | 2,816.155 μs | 2.9856 μs | 2.6467 μs |     390 B |         - |
| Encrypt · ARIA-128-GCM (BouncyCastle)       | 128KB        | 2,927.994 μs | 2.0333 μs | 1.6979 μs |     390 B |  329384 B |
| Encrypt · ARIA-128-GCM (CryptoHives-Scalar) | 128KB        | 3,581.120 μs | 3.1611 μs | 2.8022 μs |     390 B |         - |