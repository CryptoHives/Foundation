| Description                               | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|
| Decrypt · Camellia-128-CBC (BouncyCastle) | 128B         |     1.022 μs |  0.0081 μs |  0.0076 μs |     576 B |
| Decrypt · Camellia-128-CBC (Managed)      | 128B         |     1.452 μs |  0.0118 μs |  0.0104 μs |         - |
|                                           |              |              |            |            |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 128B         |     1.001 μs |  0.0065 μs |  0.0057 μs |     576 B |
| Encrypt · Camellia-128-CBC (Managed)      | 128B         |     1.413 μs |  0.0200 μs |  0.0187 μs |         - |
|                                           |              |              |            |            |           |
| Decrypt · Camellia-128-CBC (BouncyCastle) | 1KB          |     6.689 μs |  0.0963 μs |  0.0901 μs |    2816 B |
| Decrypt · Camellia-128-CBC (Managed)      | 1KB          |    10.417 μs |  0.0840 μs |  0.0701 μs |         - |
|                                           |              |              |            |            |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 1KB          |     6.603 μs |  0.0624 μs |  0.0553 μs |    2816 B |
| Encrypt · Camellia-128-CBC (Managed)      | 1KB          |    10.242 μs |  0.2015 μs |  0.1884 μs |         - |
|                                           |              |              |            |            |           |
| Decrypt · Camellia-128-CBC (BouncyCastle) | 8KB          |    52.822 μs |  0.8813 μs |  0.7813 μs |   20736 B |
| Decrypt · Camellia-128-CBC (Managed)      | 8KB          |    81.553 μs |  0.5894 μs |  0.4921 μs |         - |
|                                           |              |              |            |            |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 8KB          |    51.406 μs |  0.4036 μs |  0.3370 μs |   20736 B |
| Encrypt · Camellia-128-CBC (Managed)      | 8KB          |    78.579 μs |  0.4203 μs |  0.3281 μs |         - |
|                                           |              |              |            |            |           |
| Decrypt · Camellia-128-CBC (BouncyCastle) | 128KB        |   825.842 μs |  6.0248 μs |  5.6356 μs |  327936 B |
| Decrypt · Camellia-128-CBC (Managed)      | 128KB        | 1,320.078 μs | 22.1425 μs | 20.7121 μs |         - |
|                                           |              |              |            |            |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 128KB        |   820.326 μs | 11.9028 μs | 10.5515 μs |  327936 B |
| Encrypt · Camellia-128-CBC (Managed)      | 128KB        | 1,251.589 μs | 10.5119 μs |  9.3185 μs |         - |