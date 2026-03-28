| Description                               | TestDataSize | Mean         | Error      | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|-----------:|----------:|----------:|
| Decrypt · Camellia-128-CBC (BouncyCastle) | 128B         |     1.082 μs |  0.0087 μs | 0.0082 μs |     576 B |
| Decrypt · Camellia-128-CBC (Managed)      | 128B         |     1.551 μs |  0.0101 μs | 0.0094 μs |         - |
|                                           |              |              |            |           |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 128B         |     1.081 μs |  0.0097 μs | 0.0091 μs |     576 B |
| Encrypt · Camellia-128-CBC (Managed)      | 128B         |     1.533 μs |  0.0111 μs | 0.0104 μs |         - |
|                                           |              |              |            |           |           |
| Decrypt · Camellia-128-CBC (BouncyCastle) | 1KB          |     7.107 μs |  0.0246 μs | 0.0192 μs |    2816 B |
| Decrypt · Camellia-128-CBC (Managed)      | 1KB          |    11.141 μs |  0.0315 μs | 0.0295 μs |         - |
|                                           |              |              |            |           |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 1KB          |     7.181 μs |  0.0752 μs | 0.0703 μs |    2816 B |
| Encrypt · Camellia-128-CBC (Managed)      | 1KB          |    10.745 μs |  0.0664 μs | 0.0589 μs |         - |
|                                           |              |              |            |           |           |
| Decrypt · Camellia-128-CBC (BouncyCastle) | 8KB          |    55.837 μs |  0.3762 μs | 0.3519 μs |   20736 B |
| Decrypt · Camellia-128-CBC (Managed)      | 8KB          |    87.186 μs |  0.3255 μs | 0.2886 μs |         - |
|                                           |              |              |            |           |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 8KB          |    55.422 μs |  1.0698 μs | 1.2735 μs |   20736 B |
| Encrypt · Camellia-128-CBC (Managed)      | 8KB          |    85.249 μs |  1.1283 μs | 1.0554 μs |         - |
|                                           |              |              |            |           |           |
| Decrypt · Camellia-128-CBC (BouncyCastle) | 128KB        |   884.457 μs |  4.0997 μs | 3.8348 μs |  327936 B |
| Decrypt · Camellia-128-CBC (Managed)      | 128KB        | 1,396.294 μs |  7.1908 μs | 6.3745 μs |         - |
|                                           |              |              |            |           |           |
| Encrypt · Camellia-128-CBC (BouncyCastle) | 128KB        |   902.659 μs |  6.9032 μs | 5.7645 μs |  327936 B |
| Encrypt · Camellia-128-CBC (Managed)      | 128KB        | 1,329.535 μs | 10.7053 μs | 8.3580 μs |         - |