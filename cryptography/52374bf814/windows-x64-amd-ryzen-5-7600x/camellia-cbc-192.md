| Description                               | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Camellia-192-CBC (BouncyCastle) | 128B         |     1.271 μs |  0.0248 μs |  0.0232 μs |     584 B |
| Decrypt · Camellia-192-CBC (Managed)      | 128B         |     1.786 μs |  0.0088 μs |  0.0083 μs |         - |
|                                           |              |              |            |            |           |
| Encrypt · Camellia-192-CBC (BouncyCastle) | 128B         |     1.238 μs |  0.0058 μs |  0.0052 μs |     584 B |
| Encrypt · Camellia-192-CBC (Managed)      | 128B         |     1.787 μs |  0.0145 μs |  0.0136 μs |         - |
|                                           |              |              |            |            |           |
| Decrypt · Camellia-192-CBC (BouncyCastle) | 1KB          |     8.473 μs |  0.1680 μs |  0.1650 μs |    2824 B |
| Decrypt · Camellia-192-CBC (Managed)      | 1KB          |    12.967 μs |  0.1994 μs |  0.1768 μs |         - |
|                                           |              |              |            |            |           |
| Encrypt · Camellia-192-CBC (BouncyCastle) | 1KB          |     8.390 μs |  0.1259 μs |  0.1178 μs |    2824 B |
| Encrypt · Camellia-192-CBC (Managed)      | 1KB          |    12.791 μs |  0.0756 μs |  0.0670 μs |         - |
|                                           |              |              |            |            |           |
| Decrypt · Camellia-192-CBC (BouncyCastle) | 8KB          |    64.137 μs |  0.1727 μs |  0.1442 μs |   20744 B |
| Decrypt · Camellia-192-CBC (Managed)      | 8KB          |   101.723 μs |  1.5438 μs |  1.3685 μs |         - |
|                                           |              |              |            |            |           |
| Encrypt · Camellia-192-CBC (BouncyCastle) | 8KB          |    64.050 μs |  0.7338 μs |  0.6864 μs |   20744 B |
| Encrypt · Camellia-192-CBC (Managed)      | 8KB          |   101.838 μs |  1.8623 μs |  1.7420 μs |         - |
|                                           |              |              |            |            |           |
| Decrypt · Camellia-192-CBC (BouncyCastle) | 128KB        | 1,037.207 μs | 15.7039 μs | 13.1134 μs |  327944 B |
| Decrypt · Camellia-192-CBC (Managed)      | 128KB        | 1,602.777 μs |  7.9643 μs |  7.4498 μs |         - |
|                                           |              |              |            |            |           |
| Encrypt · Camellia-192-CBC (BouncyCastle) | 128KB        | 1,017.083 μs |  9.5319 μs |  8.9162 μs |  327944 B |
| Encrypt · Camellia-192-CBC (Managed)      | 128KB        | 1,605.524 μs |  7.7819 μs |  7.2792 μs |         - |