| Description                               | TestDataSize | Mean        | Error | Allocated |
|------------------------------------------ |------------- |------------:|------:|----------:|
| Decrypt · Camellia-256-CBC (BouncyCastle) | 128B         |    579.4 μs |    NA |     592 B |
| Decrypt · Camellia-256-CBC (Managed)      | 128B         |    717.6 μs |    NA |         - |
|                                           |              |             |       |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 128B         |    431.6 μs |    NA |     592 B |
| Encrypt · Camellia-256-CBC (Managed)      | 128B         |    720.6 μs |    NA |         - |
|                                           |              |             |       |           |
| Decrypt · Camellia-256-CBC (BouncyCastle) | 1KB          |    695.7 μs |    NA |    2832 B |
| Decrypt · Camellia-256-CBC (Managed)      | 1KB          |    878.6 μs |    NA |         - |
|                                           |              |             |       |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 1KB          |    357.1 μs |    NA |    2832 B |
| Encrypt · Camellia-256-CBC (Managed)      | 1KB          |    562.7 μs |    NA |         - |
|                                           |              |             |       |           |
| Decrypt · Camellia-256-CBC (BouncyCastle) | 8KB          |  1,069.2 μs |    NA |   20752 B |
| Decrypt · Camellia-256-CBC (Managed)      | 8KB          |  2,062.2 μs |    NA |         - |
|                                           |              |             |       |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 8KB          |    601.4 μs |    NA |   20752 B |
| Encrypt · Camellia-256-CBC (Managed)      | 8KB          |  1,541.7 μs |    NA |         - |
|                                           |              |             |       |           |
| Decrypt · Camellia-256-CBC (BouncyCastle) | 128KB        |  6,977.8 μs |    NA |  327952 B |
| Decrypt · Camellia-256-CBC (Managed)      | 128KB        | 19,748.6 μs |    NA |         - |
|                                           |              |             |       |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 128KB        |  6,178.6 μs |    NA |  327952 B |
| Encrypt · Camellia-256-CBC (Managed)      | 128KB        | 19,515.2 μs |    NA |         - |