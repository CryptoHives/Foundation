| Description                               | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Camellia-256-CBC (BouncyCastle) | 128B         |     1.169 μs | 0.0037 μs | 0.0035 μs |     592 B |
| Decrypt · Camellia-256-CBC (Managed)      | 128B         |     1.904 μs | 0.0088 μs | 0.0082 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 128B         |     1.160 μs | 0.0040 μs | 0.0035 μs |     592 B |
| Encrypt · Camellia-256-CBC (Managed)      | 128B         |     2.014 μs | 0.0070 μs | 0.0066 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-256-CBC (BouncyCastle) | 1KB          |     7.787 μs | 0.0386 μs | 0.0361 μs |    2832 B |
| Decrypt · Camellia-256-CBC (Managed)      | 1KB          |    13.417 μs | 0.0418 μs | 0.0370 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 1KB          |     8.160 μs | 0.1230 μs | 0.1027 μs |    2832 B |
| Encrypt · Camellia-256-CBC (Managed)      | 1KB          |    14.476 μs | 0.0520 μs | 0.0461 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-256-CBC (BouncyCastle) | 8KB          |    58.380 μs | 0.1671 μs | 0.1396 μs |   20752 B |
| Decrypt · Camellia-256-CBC (Managed)      | 8KB          |   107.567 μs | 0.6596 μs | 0.6170 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 8KB          |    59.039 μs | 0.1537 μs | 0.1362 μs |   20752 B |
| Encrypt · Camellia-256-CBC (Managed)      | 8KB          |   114.540 μs | 0.4344 μs | 0.4063 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-256-CBC (BouncyCastle) | 128KB        |   933.643 μs | 1.8411 μs | 1.6321 μs |  327952 B |
| Decrypt · Camellia-256-CBC (Managed)      | 128KB        | 1,697.288 μs | 8.4801 μs | 7.9323 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 128KB        |   935.850 μs | 2.3988 μs | 2.2438 μs |  327952 B |
| Encrypt · Camellia-256-CBC (Managed)      | 128KB        | 1,830.016 μs | 6.0824 μs | 5.6895 μs |         - |