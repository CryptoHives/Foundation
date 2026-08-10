| Description                               | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Camellia-192-CBC (BouncyCastle) | 128B         |     1.169 μs | 0.0032 μs | 0.0030 μs |     584 B |
| Decrypt · Camellia-192-CBC (Managed)      | 128B         |     1.899 μs | 0.0179 μs | 0.0167 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-192-CBC (BouncyCastle) | 128B         |     1.204 μs | 0.0038 μs | 0.0036 μs |     584 B |
| Encrypt · Camellia-192-CBC (Managed)      | 128B         |     2.016 μs | 0.0130 μs | 0.0122 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-192-CBC (BouncyCastle) | 1KB          |     7.574 μs | 0.0132 μs | 0.0123 μs |    2824 B |
| Decrypt · Camellia-192-CBC (Managed)      | 1KB          |    13.537 μs | 0.1026 μs | 0.0909 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-192-CBC (BouncyCastle) | 1KB          |     7.655 μs | 0.0233 μs | 0.0218 μs |    2824 B |
| Encrypt · Camellia-192-CBC (Managed)      | 1KB          |    14.502 μs | 0.0596 μs | 0.0557 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-192-CBC (BouncyCastle) | 8KB          |    59.175 μs | 0.1977 μs | 0.1849 μs |   20744 B |
| Decrypt · Camellia-192-CBC (Managed)      | 8KB          |   106.335 μs | 0.7679 μs | 0.7183 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-192-CBC (BouncyCastle) | 8KB          |    61.268 μs | 0.2403 μs | 0.2248 μs |   20744 B |
| Encrypt · Camellia-192-CBC (Managed)      | 8KB          |   114.082 μs | 0.3536 μs | 0.3307 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-192-CBC (BouncyCastle) | 128KB        |   931.018 μs | 3.6966 μs | 3.4578 μs |  327944 B |
| Decrypt · Camellia-192-CBC (Managed)      | 128KB        | 1,709.997 μs | 7.9783 μs | 7.0726 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-192-CBC (BouncyCastle) | 128KB        |   963.892 μs | 1.7405 μs | 1.6280 μs |  327944 B |
| Encrypt · Camellia-192-CBC (Managed)      | 128KB        | 1,823.501 μs | 8.7041 μs | 8.1418 μs |         - |