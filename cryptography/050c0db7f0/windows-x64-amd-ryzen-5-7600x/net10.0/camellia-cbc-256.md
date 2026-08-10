| Description                               | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Camellia-256-CBC (BouncyCastle) | 128B         |     1.314 μs | 0.0022 μs | 0.0018 μs |     592 B |
| Decrypt · Camellia-256-CBC (Managed)      | 128B         |     1.880 μs | 0.0057 μs | 0.0054 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 128B         |     1.318 μs | 0.0048 μs | 0.0045 μs |     592 B |
| Encrypt · Camellia-256-CBC (Managed)      | 128B         |     1.879 μs | 0.0041 μs | 0.0036 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-256-CBC (BouncyCastle) | 1KB          |     8.758 μs | 0.0194 μs | 0.0172 μs |    2832 B |
| Decrypt · Camellia-256-CBC (Managed)      | 1KB          |    13.508 μs | 0.0265 μs | 0.0235 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 1KB          |     8.687 μs | 0.0231 μs | 0.0193 μs |    2832 B |
| Encrypt · Camellia-256-CBC (Managed)      | 1KB          |    13.585 μs | 0.0338 μs | 0.0316 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-256-CBC (BouncyCastle) | 8KB          |    68.821 μs | 0.1365 μs | 0.1276 μs |   20752 B |
| Decrypt · Camellia-256-CBC (Managed)      | 8KB          |   106.792 μs | 0.2561 μs | 0.2396 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 8KB          |    67.883 μs | 0.0961 μs | 0.0852 μs |   20752 B |
| Encrypt · Camellia-256-CBC (Managed)      | 8KB          |   106.302 μs | 0.2407 μs | 0.2252 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-256-CBC (BouncyCastle) | 128KB        | 1,089.015 μs | 2.9223 μs | 2.2816 μs |  327952 B |
| Decrypt · Camellia-256-CBC (Managed)      | 128KB        | 1,689.340 μs | 2.9251 μs | 2.7361 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 128KB        | 1,081.240 μs | 2.0574 μs | 1.6063 μs |  327952 B |
| Encrypt · Camellia-256-CBC (Managed)      | 128KB        | 1,718.049 μs | 7.6664 μs | 6.7960 μs |         - |