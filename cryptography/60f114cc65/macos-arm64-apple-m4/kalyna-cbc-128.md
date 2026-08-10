| Description                             | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|---------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Kalyna-128-CBC (Managed)      | 128B         |     2.250 μs | 0.0009 μs | 0.0009 μs |         - |
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 128B         |     2.413 μs | 0.0005 μs | 0.0005 μs |     872 B |
|                                         |              |              |           |           |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 128B         |     1.266 μs | 0.0007 μs | 0.0006 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 128B         |     2.039 μs | 0.0033 μs | 0.0029 μs |         - |
|                                         |              |              |           |           |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 1KB          |    15.370 μs | 0.0065 μs | 0.0061 μs |     872 B |
| Decrypt · Kalyna-128-CBC (Managed)      | 1KB          |    16.171 μs | 0.0052 μs | 0.0049 μs |         - |
|                                         |              |              |           |           |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 1KB          |     7.148 μs | 0.0072 μs | 0.0067 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 1KB          |    14.603 μs | 0.0093 μs | 0.0073 μs |         - |
|                                         |              |              |           |           |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 8KB          |   118.919 μs | 0.0289 μs | 0.0257 μs |     872 B |
| Decrypt · Kalyna-128-CBC (Managed)      | 8KB          |   127.470 μs | 0.0385 μs | 0.0360 μs |         - |
|                                         |              |              |           |           |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 8KB          |    54.180 μs | 0.0722 μs | 0.0675 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 8KB          |   115.151 μs | 0.1293 μs | 0.1209 μs |         - |
|                                         |              |              |           |           |           |
| Decrypt · Kalyna-128-CBC (BouncyCastle) | 128KB        | 1,894.362 μs | 0.6083 μs | 0.5392 μs |     872 B |
| Decrypt · Kalyna-128-CBC (Managed)      | 128KB        | 2,038.419 μs | 0.8849 μs | 0.8278 μs |         - |
|                                         |              |              |           |           |           |
| Encrypt · Kalyna-128-CBC (BouncyCastle) | 128KB        |   858.677 μs | 1.2919 μs | 1.1452 μs |     872 B |
| Encrypt · Kalyna-128-CBC (Managed)      | 128KB        | 1,839.467 μs | 1.0020 μs | 0.9373 μs |         - |