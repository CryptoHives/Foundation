| Description                                     | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|------------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     4.251 μs |  0.0036 μs |  0.0032 μs |     576 B |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     6.859 μs |  0.0327 μs |  0.0255 μs |         - |
|                                                 |              |              |            |            |           |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128B         |     4.286 μs |  0.0036 μs |  0.0032 μs |     576 B |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128B         |     7.457 μs |  0.1422 μs |  0.1522 μs |         - |
|                                                 |              |              |            |            |           |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |    27.588 μs |  0.0301 μs |  0.0235 μs |    2816 B |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |    49.280 μs |  0.2645 μs |  0.2345 μs |         - |
|                                                 |              |              |            |            |           |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 1KB          |    28.157 μs |  0.0351 μs |  0.0311 μs |    2816 B |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 1KB          |    51.373 μs |  0.0168 μs |  0.0131 μs |         - |
|                                                 |              |              |            |            |           |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |   213.311 μs |  0.4259 μs |  0.3984 μs |   20736 B |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |   387.600 μs |  1.0836 μs |  0.9049 μs |         - |
|                                                 |              |              |            |            |           |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 8KB          |   215.684 μs |  0.4628 μs |  0.4329 μs |   20736 B |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 8KB          |   418.124 μs |  3.9664 μs |  3.7102 μs |         - |
|                                                 |              |              |            |            |           |
| Decrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 3,381.051 μs | 16.0211 μs | 14.9862 μs |  327936 B |
| Decrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 6,248.573 μs |  3.6815 μs |  2.8743 μs |         - |
|                                                 |              |              |            |            |           |
| Encrypt · Camellia-128-CBC (BouncyCastle)       | 128KB        | 3,448.344 μs | 14.2716 μs | 11.9174 μs |  327936 B |
| Encrypt · Camellia-128-CBC (CryptoHives-Scalar) | 128KB        | 6,467.416 μs |  2.4332 μs |  2.0319 μs |         - |