| Description                               | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Camellia-128-CBC (BouncyCastle) | 128B         |     1.072 μs | 0.0039 μs | 0.0032 μs |     576 B |
| Decrypt · Camellia-128-CBC (Managed)      | 128B         |     1.533 μs | 0.0043 μs | 0.0041 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 128B         |     1.076 μs | 0.0040 μs | 0.0037 μs |     576 B |
| Encrypt · Camellia-128-CBC (Managed)      | 128B         |     1.517 μs | 0.0135 μs | 0.0113 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-128-CBC (BouncyCastle) | 1KB          |     7.045 μs | 0.0259 μs | 0.0242 μs |    2816 B |
| Decrypt · Camellia-128-CBC (Managed)      | 1KB          |    10.961 μs | 0.0247 μs | 0.0231 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 1KB          |     6.978 μs | 0.0263 μs | 0.0246 μs |    2816 B |
| Encrypt · Camellia-128-CBC (Managed)      | 1KB          |    10.571 μs | 0.0333 μs | 0.0295 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-128-CBC (BouncyCastle) | 8KB          |    55.370 μs | 0.1415 μs | 0.1324 μs |   20736 B |
| Decrypt · Camellia-128-CBC (Managed)      | 8KB          |    86.643 μs | 0.2033 μs | 0.1902 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 8KB          |    54.616 μs | 0.2800 μs | 0.2482 μs |   20736 B |
| Encrypt · Camellia-128-CBC (Managed)      | 8KB          |    83.675 μs | 0.1188 μs | 0.0992 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-128-CBC (BouncyCastle) | 128KB        |   909.832 μs | 1.9444 μs | 1.8188 μs |  327936 B |
| Decrypt · Camellia-128-CBC (Managed)      | 128KB        | 1,383.458 μs | 3.1128 μs | 2.9117 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 128KB        |   867.245 μs | 1.9843 μs | 1.7590 μs |  327936 B |
| Encrypt · Camellia-128-CBC (Managed)      | 128KB        | 1,326.241 μs | 2.2856 μs | 1.9085 μs |         - |