| Description                               | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| Decrypt · Camellia-256-CBC (BouncyCastle) | 128B         |     1.240 μs | 0.0082 μs | 0.0077 μs |     592 B |
| Decrypt · Camellia-256-CBC (Managed)      | 128B         |     1.784 μs | 0.0098 μs | 0.0082 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 128B         |     1.237 μs | 0.0083 μs | 0.0078 μs |     592 B |
| Encrypt · Camellia-256-CBC (Managed)      | 128B         |     1.794 μs | 0.0094 μs | 0.0084 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-256-CBC (BouncyCastle) | 1KB          |     8.253 μs | 0.0306 μs | 0.0271 μs |    2832 B |
| Decrypt · Camellia-256-CBC (Managed)      | 1KB          |    12.815 μs | 0.0596 μs | 0.0557 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 1KB          |     8.152 μs | 0.0608 μs | 0.0568 μs |    2832 B |
| Encrypt · Camellia-256-CBC (Managed)      | 1KB          |    12.964 μs | 0.1485 μs | 0.1389 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-256-CBC (BouncyCastle) | 8KB          |    65.207 μs | 0.4085 μs | 0.3821 μs |   20752 B |
| Decrypt · Camellia-256-CBC (Managed)      | 8KB          |   100.907 μs | 0.3547 μs | 0.3318 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 8KB          |    63.550 μs | 0.3415 μs | 0.3028 μs |   20752 B |
| Encrypt · Camellia-256-CBC (Managed)      | 8KB          |   101.120 μs | 0.7619 μs | 0.7126 μs |         - |
|                                           |              |              |           |           |           |
| Decrypt · Camellia-256-CBC (BouncyCastle) | 128KB        | 1,036.345 μs | 7.1202 μs | 6.6603 μs |  327952 B |
| Decrypt · Camellia-256-CBC (Managed)      | 128KB        | 1,605.539 μs | 7.9234 μs | 7.4116 μs |         - |
|                                           |              |              |           |           |           |
| Encrypt · Camellia-256-CBC (BouncyCastle) | 128KB        | 1,014.565 μs | 5.8037 μs | 4.8464 μs |  327952 B |
| Encrypt · Camellia-256-CBC (Managed)      | 128KB        | 1,603.199 μs | 5.5581 μs | 4.9271 μs |         - |