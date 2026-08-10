| Description                               | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Camellia-256-CBC (BouncyCastle) | 128B         |     1.209 μs | 0.0023 μs | 0.0022 μs |     592 B |
| Decrypt · Camellia-256-CBC (Managed)      | 128B         |     1.886 μs | 0.0077 μs | 0.0072 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 128B         |     1.163 μs | 0.0021 μs | 0.0019 μs |     592 B |
| Encrypt · Camellia-256-CBC (Managed)      | 128B         |     2.000 μs | 0.0097 μs | 0.0090 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-256-CBC (BouncyCastle) | 1KB          |     7.820 μs | 0.0190 μs | 0.0178 μs |    2832 B |
| Decrypt · Camellia-256-CBC (Managed)      | 1KB          |    13.549 μs | 0.0402 μs | 0.0356 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 1KB          |     7.651 μs | 0.0230 μs | 0.0215 μs |    2832 B |
| Encrypt · Camellia-256-CBC (Managed)      | 1KB          |    14.490 μs | 0.0282 μs | 0.0250 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-256-CBC (BouncyCastle) | 8KB          |    58.990 μs | 0.1053 μs | 0.0933 μs |   20752 B |
| Decrypt · Camellia-256-CBC (Managed)      | 8KB          |   105.120 μs | 0.2710 μs | 0.2535 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 8KB          |    58.807 μs | 0.1154 μs | 0.1080 μs |   20752 B |
| Encrypt · Camellia-256-CBC (Managed)      | 8KB          |   113.476 μs | 0.2769 μs | 0.2590 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-256-CBC (BouncyCastle) | 128KB        |   929.266 μs | 1.6884 μs | 1.5793 μs |  327952 B |
| Decrypt · Camellia-256-CBC (Managed)      | 128KB        | 1,685.905 μs | 6.2080 μs | 5.8070 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 128KB        |   953.540 μs | 2.4130 μs | 2.2571 μs |  327952 B |
| Encrypt · Camellia-256-CBC (Managed)      | 128KB        | 1,817.041 μs | 5.5474 μs | 5.1891 μs |         - |