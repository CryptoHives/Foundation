| Description                               | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Camellia-256-CBC (BouncyCastle) | 128B         |     1.267 μs |  0.0136 μs |  0.0114 μs |     592 B |
| Decrypt · Camellia-256-CBC (Managed)      | 128B         |     1.791 μs |  0.0067 μs |  0.0056 μs |         - |
|                                           |              |              |            |            |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 128B         |     1.259 μs |  0.0164 μs |  0.0154 μs |     592 B |
| Encrypt · Camellia-256-CBC (Managed)      | 128B         |     1.786 μs |  0.0164 μs |  0.0154 μs |         - |
|                                           |              |              |            |            |           |
| Decrypt · Camellia-256-CBC (BouncyCastle) | 1KB          |     8.313 μs |  0.0652 μs |  0.0578 μs |    2832 B |
| Decrypt · Camellia-256-CBC (Managed)      | 1KB          |    12.811 μs |  0.1201 μs |  0.1003 μs |         - |
|                                           |              |              |            |            |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 1KB          |     8.251 μs |  0.1520 μs |  0.1348 μs |    2832 B |
| Encrypt · Camellia-256-CBC (Managed)      | 1KB          |    13.033 μs |  0.2203 μs |  0.1840 μs |         - |
|                                           |              |              |            |            |           |
| Decrypt · Camellia-256-CBC (BouncyCastle) | 8KB          |    64.386 μs |  0.2426 μs |  0.2150 μs |   20752 B |
| Decrypt · Camellia-256-CBC (Managed)      | 8KB          |   100.900 μs |  0.3446 μs |  0.2690 μs |         - |
|                                           |              |              |            |            |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 8KB          |    63.958 μs |  0.3796 μs |  0.3550 μs |   20752 B |
| Encrypt · Camellia-256-CBC (Managed)      | 8KB          |   100.337 μs |  0.3747 μs |  0.3321 μs |         - |
|                                           |              |              |            |            |           |
| Decrypt · Camellia-256-CBC (BouncyCastle) | 128KB        | 1,026.042 μs |  5.1160 μs |  4.5352 μs |  327952 B |
| Decrypt · Camellia-256-CBC (Managed)      | 128KB        | 1,597.316 μs |  3.9247 μs |  3.6712 μs |         - |
|                                           |              |              |            |            |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 128KB        | 1,027.007 μs | 16.1018 μs | 15.0616 μs |  327952 B |
| Encrypt · Camellia-256-CBC (Managed)      | 128KB        | 1,624.906 μs |  8.7419 μs |  6.8251 μs |         - |