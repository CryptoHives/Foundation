| Description                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     1.478 μs | 0.0023 μs | 0.0018 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.475 μs | 0.0047 μs | 0.0042 μs |    1208 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128B         |     1.486 μs | 0.0074 μs | 0.0070 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128B         |     2.385 μs | 0.0049 μs | 0.0044 μs |    1208 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    10.579 μs | 0.0145 μs | 0.0113 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    15.449 μs | 0.0250 μs | 0.0209 μs |    3448 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 1KB          |    10.585 μs | 0.0161 μs | 0.0134 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 1KB          |    16.152 μs | 0.0170 μs | 0.0133 μs |    3448 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    83.585 μs | 0.2039 μs | 0.1907 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   119.176 μs | 0.1949 μs | 0.1728 μs |   21368 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 8KB          |    83.307 μs | 0.0787 μs | 0.0657 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 8KB          |   121.644 μs | 0.6064 μs | 0.4735 μs |   21368 B |
|                                             |              |              |           |           |           |
| Decrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 1,334.801 μs | 2.8154 μs | 2.3510 μs |         - |
| Decrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,896.786 μs | 2.8962 μs | 2.5674 μs |  328568 B |
|                                             |              |              |           |           |           |
| Encrypt · ARIA-128-CBC (CryptoHives-Scalar) | 128KB        | 1,333.901 μs | 2.7724 μs | 2.5933 μs |         - |
| Encrypt · ARIA-128-CBC (BouncyCastle)       | 128KB        | 1,926.181 μs | 5.9631 μs | 4.9794 μs |  328568 B |