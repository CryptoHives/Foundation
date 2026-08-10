| Description                               | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Camellia-192-CBC (BouncyCastle) | 128B         |     1.248 μs | 0.0093 μs | 0.0087 μs |     584 B |
| Decrypt · Camellia-192-CBC (Managed)      | 128B         |     1.780 μs | 0.0060 μs | 0.0050 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-192-CBC (BouncyCastle) | 128B         |     1.242 μs | 0.0066 μs | 0.0062 μs |     584 B |
| Encrypt · Camellia-192-CBC (Managed)      | 128B         |     1.806 μs | 0.0259 μs | 0.0242 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-192-CBC (BouncyCastle) | 1KB          |     8.245 μs | 0.0546 μs | 0.0510 μs |    2824 B |
| Decrypt · Camellia-192-CBC (Managed)      | 1KB          |    12.789 μs | 0.0659 μs | 0.0584 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-192-CBC (BouncyCastle) | 1KB          |     8.143 μs | 0.0348 μs | 0.0291 μs |    2824 B |
| Encrypt · Camellia-192-CBC (Managed)      | 1KB          |    12.884 μs | 0.0949 μs | 0.0841 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-192-CBC (BouncyCastle) | 8KB          |    64.373 μs | 0.4142 μs | 0.3874 μs |   20744 B |
| Decrypt · Camellia-192-CBC (Managed)      | 8KB          |   100.956 μs | 0.3558 μs | 0.3328 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-192-CBC (BouncyCastle) | 8KB          |    63.570 μs | 0.3113 μs | 0.2759 μs |   20744 B |
| Encrypt · Camellia-192-CBC (Managed)      | 8KB          |   101.248 μs | 0.5303 μs | 0.4701 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-192-CBC (BouncyCastle) | 128KB        | 1,034.317 μs | 9.2602 μs | 8.6620 μs |  327944 B |
| Decrypt · Camellia-192-CBC (Managed)      | 128KB        | 1,604.370 μs | 5.3678 μs | 5.0211 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-192-CBC (BouncyCastle) | 128KB        | 1,011.154 μs | 4.9089 μs | 4.0992 μs |  327944 B |
| Encrypt · Camellia-192-CBC (Managed)      | 128KB        | 1,605.694 μs | 6.6185 μs | 6.1910 μs |         - |