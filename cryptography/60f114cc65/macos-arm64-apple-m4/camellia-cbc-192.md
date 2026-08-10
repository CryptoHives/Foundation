| Description                               | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Camellia-192-CBC (BouncyCastle) | 128B         |     1.168 μs | 0.0017 μs | 0.0015 μs |     584 B |
| Decrypt · Camellia-192-CBC (Managed)      | 128B         |     1.881 μs | 0.0082 μs | 0.0077 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-192-CBC (BouncyCastle) | 128B         |     1.158 μs | 0.0022 μs | 0.0021 μs |     584 B |
| Encrypt · Camellia-192-CBC (Managed)      | 128B         |     2.007 μs | 0.0089 μs | 0.0083 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-192-CBC (BouncyCastle) | 1KB          |     7.709 μs | 0.0216 μs | 0.0202 μs |    2824 B |
| Decrypt · Camellia-192-CBC (Managed)      | 1KB          |    13.448 μs | 0.0504 μs | 0.0471 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-192-CBC (BouncyCastle) | 1KB          |     7.652 μs | 0.0219 μs | 0.0205 μs |    2824 B |
| Encrypt · Camellia-192-CBC (Managed)      | 1KB          |    14.468 μs | 0.0589 μs | 0.0551 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-192-CBC (BouncyCastle) | 8KB          |    58.403 μs | 0.0952 μs | 0.0890 μs |   20744 B |
| Decrypt · Camellia-192-CBC (Managed)      | 8KB          |   107.277 μs | 0.3725 μs | 0.3485 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-192-CBC (BouncyCastle) | 8KB          |    58.888 μs | 0.1153 μs | 0.1078 μs |   20744 B |
| Encrypt · Camellia-192-CBC (Managed)      | 8KB          |   113.842 μs | 0.2831 μs | 0.2648 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-192-CBC (BouncyCastle) | 128KB        |   934.951 μs | 2.7405 μs | 2.5635 μs |  327944 B |
| Decrypt · Camellia-192-CBC (Managed)      | 128KB        | 1,719.420 μs | 9.7222 μs | 9.0941 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-192-CBC (BouncyCastle) | 128KB        |   934.562 μs | 2.7882 μs | 2.6081 μs |  327944 B |
| Encrypt · Camellia-192-CBC (Managed)      | 128KB        | 1,807.697 μs | 4.8608 μs | 4.5468 μs |         - |